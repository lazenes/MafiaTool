﻿using Mafia2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Mafia2Tool
{
    public static class SceneData
    {
        public static FrameNameTable FrameNameTable;
        public static FrameResource FrameResource;
        public static VertexBufferManager VertexBufferPool;
        public static IndexBufferManager IndexBufferPool;
        public static SoundSector SoundSector;
        public static Actor Actors;
        public static ItemDesc[] ItemDescs;
        public static Collision Collisions;
        public static CityAreas CityAreas;
        public static string ScenePath = new IniFile().Read("SDSPath", "Directories");

        public static void BuildData()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(ScenePath);
            FileInfo[] files = dirInfo.GetFiles();

            List<FileInfo> vbps = new List<FileInfo>();
            List<FileInfo> ibps = new List<FileInfo>();
            List<ItemDesc> ids = new List<ItemDesc>();
            List<Actor> act = new List<Actor>();

            foreach (FileInfo file in files)
            {
                if (file.Extension == ".fr")
                    FrameResource = new FrameResource(file.FullName);

                if (file.FullName.Contains(".fnt"))
                    FrameNameTable = new FrameNameTable(file.FullName);

                if (file.FullName.Contains(".vbp"))
                    vbps.Add(file);

                if (file.FullName.Contains(".ibp"))
                    ibps.Add(file);

                //if (file.FullName.Contains("ItemDesc"))
                //    ids.Add(new ItemDesc(file.FullName));

                //if (file.FullName.Contains("SoundSector"))
                //    SoundSector = new SoundSector(file.FullName);

                if (file.FullName.Contains(".act"))
                    Actors = new Actor(file.FullName);

                //if (file.FullName.Contains("cityareas"))
                //    CityAreas = new CityAreas(file.FullName);
            }

            IndexBufferPool = new IndexBufferManager(ibps);
            VertexBufferPool = new VertexBufferManager(vbps);
            ItemDescs = ids.ToArray();

            for (int i = 0; i != ItemDescs.Length; i++)
                ItemDescs[i].WriteToEDC();

            if (Actors == null)
                return;

            AttachActors();
            FrameResource.UpdateEntireFrame();
        }

        public static void AttachActors()
        {
            for (int i = 0; i != Actors.Definitions.Length; i++)
            {
                for (int c = 0; c != Actors.Items.Length; c++)
                {
                    if (Actors.Items[c].Hash1 == Actors.Definitions[i].Hash)
                    {
                        FrameObjectFrame frame = FrameResource.FrameObjects[Actors.Definitions[i].FrameIndex] as FrameObjectFrame;
                        frame.Item = Actors.Items[c];
                        FrameResource.FrameObjects[Actors.Definitions[i].FrameIndex] = frame;
                    }
                }
            }
        }

        public static void Reload()
        {
            FrameNameTable = null;
            FrameResource = null;
            VertexBufferPool = null;
            IndexBufferPool = null;
            SoundSector = null;
            Actors = null;
            ItemDescs = null;
            Collisions = null;
            CityAreas = null;

            GC.Collect();
            BuildData();
        }
    }

    public static class MaterialData
    {
        public static Material[] Default;
        public static Material[] Default50;
        public static Material[] Default60;
        public static string MaterialPath = new IniFile().Read("MaterialPath", "Directories");
        public static bool HasLoaded = false;

        /// <summary>
        /// Loads all material data from user-specified path.
        /// </summary>
        public static void Load()
        {
            try
            {
                Default = MaterialsLib.ReadMatFile(MaterialPath + "/default.mtl");
                Default50 = MaterialsLib.ReadMatFile(MaterialPath + "/default50.mtl");
                Default60 = MaterialsLib.ReadMatFile(MaterialPath + "/default60.mtl");
                HasLoaded = true;
                MaterialsLib.SetMaterials(Default);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load materials. Error occured: \n\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
