using System;
using System.Collections.Generic;
using SharpDX;
using Gibbed.Illusion.FileFormats.Hashing;
using ResourceTypes.FrameResource;
using Utils.SharpDXExtensions;
using ResourceTypes.BufferPools;
using Utils.Types;

namespace Utils.Models
{
    public class Model
    {
        
        FrameObjectSingleMesh frameMesh; //model can be either "FrameObjectSingleMesh"
        FrameObjectModel frameModel; //Or "FrameObjectModel"
        FrameGeometry frameGeometry; //Holds geometry data, all content is built into here.
        FrameMaterial frameMaterial; //Data related to material goes into here.
        FrameBlendInfo blendInfo;
        FrameSkeleton skeleton;
        FrameSkeletonHierachy skeletonHierarchy;
        IndexBuffer[] indexBuffers; //Holds the buffer which will then be saved/replaced later
        VertexBuffer[] vertexBuffers; //Holds the buffers which will then be saved/replaced later
        M2TStructure model; //split from this file; it now includes M2T format.
        private bool useSingleMesh; //False means ModelMesh, True means SingleMesh;
        
        public FrameObjectSingleMesh FrameMesh {
            get { return frameMesh; }
            set { frameMesh = value; }
        }

        public FrameObjectModel FrameModel {
            get { return frameModel; }
            set { frameModel = value; }
        }

        public FrameGeometry FrameGeometry {
            get { return frameGeometry; }
            set { frameGeometry = value; }
        }

        public FrameMaterial FrameMaterial {
            get { return frameMaterial; }
            set { frameMaterial = value; }
        }

        public FrameBlendInfo BlendInfoBlock {
            get { return blendInfo; }
            set { blendInfo = value; }
        }

        public FrameSkeleton SkeletonBlock {
            get { return skeleton; }
            set { skeleton = value; }
        }

        public FrameSkeletonHierachy SkeletonHierachyBlock {
            get { return skeletonHierarchy; }
            set { skeletonHierarchy = value; }
        }

        public IndexBuffer[] IndexBuffers {
            get { return indexBuffers; }
            set { indexBuffers = value; }
        }

        public VertexBuffer[] VertexBuffers {
            get { return vertexBuffers; }
            set { vertexBuffers = value; }
        }

        public M2TStructure ModelStructure {
            get { return model; }
            set { model = value; }
        }

        public Model(FrameObjectSingleMesh frameMesh, IndexBuffer[] indexBuffers, VertexBuffer[] vertexBuffers)
        {
            this.frameMesh = frameMesh;
            this.indexBuffers = indexBuffers;
            this.vertexBuffers = vertexBuffers;
            frameGeometry = frameMesh.Geometry;
            frameMaterial = frameMesh.Material;
            model = new M2TStructure();
            model.IsSkinned = false;
            model.Name = frameMesh.Name.ToString();
            model.AOTexture = frameMesh.OMTextureHash.String;
            model.BuildLods(frameGeometry, frameMaterial, vertexBuffers, indexBuffers);
        }

        public Model(FrameObjectModel frameModel, IndexBuffer[] indexBuffers, VertexBuffer[] vertexBuffers)
        {
            this.frameModel = frameModel;
            this.indexBuffers = indexBuffers;
            this.vertexBuffers = vertexBuffers;
            frameGeometry = frameModel.Geometry;
            frameMaterial = frameModel.Material;
            blendInfo = frameModel.BlendInfo;
            skeleton = frameModel.Skeleton;
            skeletonHierarchy = frameModel.SkeletonHierarchy;
            model = new M2TStructure();
            model.IsSkinned = true;
            model.Name = frameModel.Name.ToString();
            model.AOTexture = frameModel.OMTextureHash.String;
            model.BuildLods(frameModel, indexBuffers, vertexBuffers);
        }

        /// <summary>
        /// Construct an empty model.
        /// </summary>
        public Model()
        {
            ModelStructure = new M2TStructure();
        }

        /// <summary>
        /// Update decompression offset and position.
        /// </summary>
        public void CalculateDecompression()
        {
            float minFloatf = 0.000016f;
            SharpDX.Vector3 minFloat = new SharpDX.Vector3(minFloatf);

            BoundingBox bounds = new BoundingBox();
            bounds.Minimum = frameMesh.Boundings.Minimum - minFloat;
            bounds.Maximum = frameMesh.Boundings.Maximum + minFloat;
            frameGeometry.DecompressionOffset = new Vector3(bounds.Minimum.X, bounds.Minimum.Y, bounds.Minimum.Z);

            double MaxX = bounds.Maximum.X - bounds.Minimum.X + minFloatf;
            double MaxY = bounds.Maximum.Y - bounds.Minimum.Y + minFloatf;
            double MaxZ = bounds.Maximum.Z - bounds.Minimum.Z + minFloatf;

            double fMaxSize = Math.Max(MaxX, Math.Max(MaxY, MaxZ * 2.0f));
            Console.WriteLine("Decompress value before: " + fMaxSize);
            double result = Math.Log(fMaxSize) / Math.Log(2.0f);
            double pow = Math.Ceiling(result);
            double factor = Math.Pow(2.0f, pow);
            frameGeometry.DecompressionFactor = (float)(factor / 0x10000);

            Console.WriteLine("Using decompression value from: " + fMaxSize + " result is: " + frameGeometry.DecompressionFactor);
        }

        public void BuildIndexBuffer()
        {
            if (model.Lods == null)
                return;

            for (int i = 0; i < model.Lods.Length; i++)
            {
                var indexFormat = (model.Lods[i].Over16BitLimit() ? 2 : 1);
                IndexBuffers[i] = new IndexBuffer(FNV64.Hash("M2TK." + model.Name + ".IB" + i));
                indexBuffers[i].SetData(model.Lods[i].Indices);
                indexBuffers[i].SetFormat(indexFormat);
            }
        }

        /// <summary>
        /// Builds vertex buffer from the mesh data.
        /// </summary>
        public void BuildVertexBuffer()
        {
            if (model.Lods == null)
                return;

            for (int i = 0; i != model.Lods.Length; i++)
            {
                FrameLOD frameLod = frameGeometry.LOD[i];
                int vertexSize;
                Dictionary<VertexFlags, FrameLOD.VertexOffset> vertexOffsets = frameLod.GetVertexOffsets(out vertexSize);
                byte[] vBuffer = new byte[vertexSize * frameLod.NumVerts];

                for (int v = 0; v != model.Lods[i].Vertices.Length; v++)
                {
                    Vertex vert = model.Lods[i].Vertices[v];

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.Position))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.Position].Offset;
                        vert.WritePositionData(vBuffer, startIndex, frameGeometry.DecompressionFactor, frameGeometry.DecompressionOffset);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.Tangent))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.Position].Offset;
                        vert.WriteTangentData(vBuffer, startIndex);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.Normals))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.Normals].Offset;
                        vert.WriteNormalData(vBuffer, startIndex);
                    }

                    if(frameLod.VertexDeclaration.HasFlag(VertexFlags.Color))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.Color].Offset;
                        vert.WriteColourData(vBuffer, startIndex, 0);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.Color1))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.Color1].Offset;
                        vert.WriteColourData(vBuffer, startIndex, 1);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.DamageGroup))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.DamageGroup].Offset;
                        vert.WriteDamageGroup(vBuffer, startIndex);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.TexCoords0))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.TexCoords0].Offset;
                        vert.WriteUvData(vBuffer, startIndex, 0);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.TexCoords1))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.TexCoords1].Offset;
                        vert.WriteUvData(vBuffer, startIndex, 1);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.TexCoords2))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.TexCoords2].Offset;
                        vert.WriteUvData(vBuffer, startIndex, 2);
                    }

                    if (frameLod.VertexDeclaration.HasFlag(VertexFlags.ShadowTexture))
                    {
                        int startIndex = v * vertexSize + vertexOffsets[VertexFlags.ShadowTexture].Offset;
                        vert.WriteUvData(vBuffer, startIndex, 3);
                    }

                }

                VertexBuffers[i] = new VertexBuffer(FNV64.Hash("M2TK." + model.Name + ".VB" + i));
                VertexBuffers[i].Data = vBuffer;
            }
        }

        public void UpdateObjectsFromModel()
        {
            frameGeometry.NumLods = (byte)model.Lods.Length;

            if (frameGeometry.LOD == null)
                frameGeometry.LOD = new FrameLOD[model.Lods.Length];

            frameMaterial.NumLods = (byte)model.Lods.Length;
            frameMaterial.LodMatCount = new int[model.Lods.Length];
            frameMaterial.Materials = new List<MaterialStruct[]>();

            for (int x = 0; x < model.Lods.Length; x++)
            {
                frameMaterial.Materials.Add(new MaterialStruct[frameMaterial.LodMatCount[x]]);
            }
            for (int x = 0; x < model.Lods.Length; x++)
            {
                var lod = new FrameLOD();
                lod.Distance = 1E+12f;
                lod.BuildNewPartition();
                lod.BuildNewMaterialSplit();
                lod.SplitInfo.NumVerts = model.Lods[x].Vertices.Length;
                lod.NumVerts = model.Lods[x].Vertices.Length;
                lod.SplitInfo.NumFaces = model.Lods[x].Indices.Length / 3;
                lod.VertexDeclaration = model.Lods[x].VertexDeclaration;

                //burst split info.
                lod.SplitInfo.IndexStride = (model.Lods[x].Over16BitLimit() ? 4 : 2);
                lod.SplitInfo.NumMatSplit = model.Lods[x].Parts.Length;
                lod.SplitInfo.NumMatBurst = model.Lods[x].Parts.Length;
                lod.SplitInfo.MaterialSplits = new FrameLOD.MaterialSplit[model.Lods[x].Parts.Length];
                lod.SplitInfo.MaterialBursts = new FrameLOD.MaterialBurst[model.Lods[x].Parts.Length];
                frameGeometry.LOD[x] = lod;

                int faceIndex = 0;
                frameMaterial.LodMatCount[x] = model.Lods[x].Parts.Length;
                frameMaterial.Materials[x] = new MaterialStruct[model.Lods[x].Parts.Length];
                for (int i = 0; i != model.Lods[x].Parts.Length; i++)
                {
                    frameMaterial.Materials[x][i] = new MaterialStruct();
                    frameMaterial.Materials[x][i].StartIndex = (int)model.Lods[x].Parts[i].StartIndex;
                    frameMaterial.Materials[x][i].NumFaces = (int)model.Lods[x].Parts[i].NumFaces;
                    frameMaterial.Materials[x][i].Unk3 = 0;
                    frameMaterial.Materials[x][i].MaterialHash = model.Lods[x].Parts[i].Hash;
                    //frameMaterial.Materials[0][i].MaterialName = model.Lods[0].Parts[i].Material;
                    faceIndex += (int)model.Lods[x].Parts[i].NumFaces;

                    frameGeometry.LOD[x].SplitInfo.MaterialBursts[i].Bounds = new short[6]
                    {
                    Convert.ToInt16(model.Lods[x].Parts[i].Bounds.Minimum.X),
                    Convert.ToInt16(model.Lods[x].Parts[i].Bounds.Minimum.Y),
                    Convert.ToInt16(model.Lods[x].Parts[i].Bounds.Minimum.Z),
                    Convert.ToInt16(model.Lods[x].Parts[i].Bounds.Maximum.X),
                    Convert.ToInt16(model.Lods[x].Parts[i].Bounds.Maximum.Y),
                    Convert.ToInt16(model.Lods[x].Parts[i].Bounds.Maximum.Z)

                    };
                    if (model.Lods[x].Parts.Length == 1)
                        frameGeometry.LOD[x].SplitInfo.Hash = model.Lods[0].Parts[0].Hash;

                    frameGeometry.LOD[x].SplitInfo.MaterialBursts[i].FirstIndex = 0;                  
                    frameGeometry.LOD[x].SplitInfo.MaterialBursts[i].LeftIndex = -1;
                    frameGeometry.LOD[x].SplitInfo.MaterialBursts[i].RightIndex = -1;
                    frameGeometry.LOD[x].SplitInfo.MaterialBursts[i].SecondIndex =
                        Convert.ToUInt16(model.Lods[x].Parts[i].NumFaces - 1);
                    frameGeometry.LOD[x].SplitInfo.MaterialSplits[i].BaseIndex = (int)model.Lods[x].Parts[i].StartIndex;
                    frameGeometry.LOD[x].SplitInfo.MaterialSplits[i].FirstBurst = i;
                    frameGeometry.LOD[x].SplitInfo.MaterialSplits[i].NumBurst = 1;
                }
            }
        }

        /// <summary>
        /// Create objects from model. Requires FrameMesh/FrameModel to be already set and a model already read into the data.
        /// </summary>
        public void CreateObjectsFromModel()
        {
            frameGeometry = new FrameGeometry();
            frameMaterial = new FrameMaterial();
          

            //set lods for all data.
            indexBuffers = new IndexBuffer[model.Lods.Length];
            vertexBuffers = new VertexBuffer[model.Lods.Length];

            List<Vertex[]> vertData = new List<Vertex[]>();
            for (int i = 0; i != model.Lods.Length; i++)
            {
                vertData.Add(model.Lods[i].Vertices);
            }

            frameMesh.Boundings = BoundingBoxExtenders.CalculateBounds(vertData);
            frameMaterial.Bounds = FrameMesh.Boundings;
            CalculateDecompression();
            UpdateObjectsFromModel();
            BuildIndexBuffer();
            BuildVertexBuffer();

            for(int i = 0; i < model.Lods.Length; i++)
            {
                var lod = frameGeometry.LOD[i];

                var size = 0;
                lod.GetVertexOffsets(out size);
                if (vertexBuffers[i].Data.Length != (size * lod.NumVerts)) throw new SystemException();
                lod.IndexBufferRef = new HashName("M2TK." + model.Name + ".IB" + i);
                lod.VertexBufferRef = new HashName("M2TK." + model.Name + ".VB" + i);
            }

            if(model.IsSkinned)
            {
                CreateSkinnedObjectsFromModel();
            }
        }

        private void CreateSkinnedObjectsFromModel()
        {
            blendInfo = new FrameBlendInfo();
            skeleton = new FrameSkeleton();
            skeletonHierarchy = new FrameSkeletonHierachy();

            int jointCount = model.SkeletonData.Joints.Length;
            skeleton.BoneNames = new HashName[jointCount];
            skeleton.NumBones = new int[4];
            skeleton.UnkLodData = new int[1];
            skeleton.BoneLODUsage = new byte[jointCount];

            skeleton.NumBlendIDs = jointCount;
            skeleton.NumUnkCount2 = jointCount;
            skeleton.UnkLodData[0] = jointCount;


            for (int i = 0; i < 4; i++)
            {
                skeleton.NumBones[i] = jointCount;
            }

            for (int i = 0; i < jointCount; i++)
            {
                HashName bone = new HashName();
                bone.Set(model.SkeletonData.Joints[i].Name);
                skeleton.BoneNames[i] = bone;

                if (model.Lods.Length == 1)
                {
                    skeleton.BoneLODUsage[i] = 1;
                }
            }

            skeletonHierarchy.ParentIndices = new byte[jointCount];
            skeletonHierarchy.LastChildIndices = new byte[jointCount];
            skeletonHierarchy.UnkData = new byte[jointCount];
            skeleton.JointTransforms = new Matrix[jointCount];

            skeletonHierarchy.UnkData[0] = (byte)(jointCount + 1);

            for (int i = 0; i < jointCount; i++)
            {
                skeletonHierarchy.ParentIndices[i] = model.SkeletonData.Joints[i].ParentIndex;
                skeletonHierarchy.UnkData[i] = (byte)(i != jointCount ? i : 0);
                skeleton.JointTransforms[i] = model.SkeletonData.Joints[i].LocalTransform;
            }
        }
    }
}
