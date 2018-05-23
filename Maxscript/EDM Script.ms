global edmLastFile = ""
global eddLastFile = ""
global edmPath = ""
global aMeshes = #()

struct Part
(
	mesh
)	
struct EddStruct
(
	fileName,
	pos
)

fn importFrame =
(
	eddFile = fopen eddLastFile "rb"
	files = #()
	files.count = readlong eddFile
	
	for i = 1 to files.count do
	(
		count = readbyte eddFile

		fa = ""
		char_array = #()
		char_array.count = count
		for i= 1 to count do
		(
			char_array[i] = readbyte eddFile
			fa += bit.intAsChar char_array[i]
		)
	
		pos = [0,0,0]
		pos.x = readfloat eddFile
		pos.y = readfloat eddFile
		pos.z = readfloat eddFile
		
		files[i] = EddStruct fileName: fa pos: pos
	)
	fclose eddFile
	
	for i = 1 to files.count do
	(
		edmLastFile = (edmPath +"\\" + files[i].fileName + ".edm")
		importMesh()
	)
	for i = 1 to files.count do
	(
		aMeshes[i].pos = files[i].pos
	)
	
)
fn importMesh =
(
	file = fopen edmLastFile "rb"
	
	root= Dummy();
	root.boxsize=[1,1,1]
	count = readbyte file
	sString = ""
	char_array = #()
	char_array.count = count
	for i= 1 to count do
	(
		char_array[i] = readbyte file
		sString += bit.intAsChar char_array[i]
	)

	root.name = sString

	aParts = #()
	aParts.count = readlong file

	for i = 1 to aParts.count do
	(
		count = readbyte file
		meshString = ""
		char_array = #()
		char_array.count = count
		for i= 1 to count do
		(
			char_array[i] = readbyte file
			meshString += bit.intAsChar char_array[i]
		)

		vertarray = #()
		vertarray.count = readlong file	
	
		for i = 1 to vertarray.count do
		(
			vert = [0,0,0]
			vert.x = readfloat file
			vert.y = readfloat file
			vert.z = readfloat file
			vertarray[i] = vert
			i+=2
		)
	
		tvertarray = #()
		tvertarray.count = readlong file
	
		for i = 1 to tvertarray.count do
		(
			tvert = [0,0,0]
			tvert.x = readfloat file
			tvert.y = readfloat file
			tvertarray[i] = tvert
			i+=1
		)
	
		facearray = #()
		facearray.count = readlong file	
	
		for i = 1 to facearray.count do
		(
			face = [0,0,0]
			face.x = readlong file
			face.y = readlong file
			face.z = readlong file
			facearray[i] = face
			i+=2
		)
	
		mesh1 = mesh vertices:vertarray tverts:tvertarray faces:facearray
		mesh1.name = meshString
		mesh1.parent = root
		
		if getNumTVerts mesh1 > 0 then
			buildTVFaces mesh1
		
		for i = 1 to mesh1.numfaces do(setTVFace mesh1 i (getFace mesh1 i))
	
		aParts[i]=Part mesh: mesh1
	)
	append aMeshes root
	fclose file
)

utility EDMImport "EDM Importer"
(
	group "Import"
	(
		button importer "Import Single Mesh"
		button fimporter "Import Entire Folder"
	)
	
	group "About"
	(
		label title "EDM Importer"
		label desc "Imports EDM files"
	)
	
	on importer pressed do
	(
		edmFile = getopenfilename caption:"Select File" filename: edmLastFile types:"edm (*.edm)"
		edmLastFile = edmFile
		importMesh()
	)
	on fimporter pressed do
	(
		edmPath = getSavePath caption:"Select Folder" initialDir:"C:\\Users\\Connor\\source\\repos\\Mafia2Tools\\Mafia2Tools\\Mafia2Libs\\bin\\Debug\\exported"
		files = getFiles (edmpath+"\\*.edd")
		
		eddLastFile = files[1]
		importFrame()
	)
)