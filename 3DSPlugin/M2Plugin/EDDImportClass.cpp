#include "3dsmaxsdk_preinclude.h"
#include "EDDImportClass.h"
#include "M2EDD.h"
#include "M2EDM.h"
#include <vector>
#include "triobj.h"
#include <impapi.h>
#include "dummy.h"

#define EDD_IMPORT_CLASS_ID	Class_ID(0x13343918, 0x75cf75f5)
namespace fs = std::experimental::filesystem;

class EDDImportClassDesc : public ClassDesc2
{
public:
	virtual int IsPublic() { return TRUE; }
	virtual void* Create(BOOL /*loading = FALSE*/) { return new EDDImport(); }
	virtual const TCHAR *	ClassName() { return GetString(IDS_EDD_IMPORT_CLASS); }
	virtual SClass_ID SuperClassID() { return SCENE_IMPORT_CLASS_ID; }
	virtual Class_ID ClassID() { return EDD_IMPORT_CLASS_ID; }
	virtual const TCHAR* Category() { return GetString(IDS_CATEGORY); }

	virtual const TCHAR* InternalName() { return _T("M2Plugin"); }	// returns fixed parsable name (scripter-visible name)
	virtual HINSTANCE HInstance() { return hInstance; }					// returns owning module handle


};
ClassDesc2* GetEDDImportDesc() {
	static EDDImportClassDesc EDDImportDesc;
	return &EDDImportDesc;
}

static FILE *stream = NULL;
static FILE *edmStream = NULL;

//EDD IMPORT SECTION
//=========================

EDDImport::EDDImport() {
}
EDDImport::~EDDImport() {
}
int EDDImport::ExtCount() {
	return 1;
}
const TCHAR* EDDImport::Ext(int n) {
	switch (n) {
	case 0:
		return _T("EDD");
	}
	return _T("");
}
const TCHAR* EDDImport::LongDesc() {
	return GetString(IDS_EDD_L_DESC);
}
const TCHAR* EDDImport::ShortDesc() {
	return GetString(IDS_EDD_S_DESC);
}
const TCHAR* EDDImport::AuthorName() {
	return GetString(IDS_AUTHOR);
}
const TCHAR* EDDImport::CopyrightMessage() {
	return _T("");
}
const TCHAR* EDDImport::OtherMessage1() {
	return _T("");
}
const TCHAR* EDDImport::OtherMessage2() {
	return _T("");
}
unsigned int EDDImport::Version() {
	return 1;
}
void EDDImport::ShowAbout(HWND hWnd) {}
int EDDImport::DoImport(const TCHAR* filename, ImpInterface* importerInt, Interface* ip, BOOL suppressPrompts) {
	fs::path filePath = filename;
	fs::path parentPath = filePath.parent_path();

	EDDWorkClass edm(filename, _T("rb"));
	stream = edm.Stream();

	int magic;
	fread(&magic, sizeof(int), 1, stream);

	if (magic != 808535109)
		return FALSE;

	int entryCount = 0;
	fread(&entryCount, sizeof(int), 1, stream);

	for (int i = 0; i != entryCount; i++) {
		EDDEntry entry = EDDEntry();
		entry.ReadFromStream(stream);

		fs::path edmPath = parentPath / entry.GetLodNames()[0];

		if (!fs::exists(edmPath))
			return FALSE;

		const wchar_t* wedmPath = edmPath.c_str();
		edmStream = _tfopen(wedmPath, _T("rb"));

		if (edmStream == NULL)
			return FALSE;

		EDMStructure edmStructure = EDMStructure();
		edmStructure.ReadFromStream(edmStream);

		DummyObject* parentDummy = new DummyObject();
		ImpNode* parent = importerInt->CreateNode();
		parent->Reference(parentDummy);
		parent->SetName(entry.GetLodNames()[0].c_str());

		for (int x = 0; x != edmStructure.GetPartSize(); x++) {
			TriObject* triObject = CreateNewTriObject();
			Mesh &mesh = triObject->GetMesh();

			EDMPart part = edmStructure.GetParts()[x];

			std::vector<Point3> verts = part.GetVertices();
			std::vector<UVVert> uvs = part.GetUVs();
			std::vector<Int3> indices = part.GetIndices();

			mesh.setNumVerts(part.GetVertSize());
			for (int z = 0; z != mesh.numVerts; z++) {
				mesh.setVert(z, verts[z]);
			}

			mesh.setNumMaps(2);
			mesh.setMapSupport(1, true);
			MeshMap &map = mesh.Map(1);
			map.setNumVerts(part.GetUVSize());

			for (int z = 0; z != part.GetUVSize(); z++) {
				map.tv[z].x = uvs[z].x;
				map.tv[z].y = uvs[z].y;
				map.tv[z].z = 0.0f;
			}

			mesh.setNumFaces(part.GetIndicesSize());
			map.setNumFaces(part.GetIndicesSize());

			for (int z = 0; z != mesh.numFaces; z++) {
				mesh.faces[z].setVerts(indices[z].i1, indices[z].i2, indices[z].i3);
				mesh.faces[z].setMatID(1);
				mesh.faces[z].setEdgeVisFlags(1, 1, 1);
				map.tf[z].setTVerts(indices[z].i1, indices[z].i2, indices[z].i3);
			}

			mesh.InvalidateGeomCache();
			mesh.InvalidateTopologyCache();

			ImpNode *node = importerInt->CreateNode();
			INode *inode = node->GetINode();
			node->Reference(triObject);
			node->SetName(part.GetName().c_str());

			importerInt->AddNodeToScene(node);
			inode = node->GetINode();
			parent->GetINode()->AttachChild(inode, 0);
			Matrix3 tm = entry.GetMatrix();
			parent->SetTransform(0, tm);
			importerInt->AddNodeToScene(parent);
		}
		edmStream = NULL;
	}
	importerInt->RedrawViews();

	return TRUE;
}
