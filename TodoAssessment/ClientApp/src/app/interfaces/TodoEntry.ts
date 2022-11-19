type GUID = string & { isGuid: true };
function guid(guid: string): GUID {
	return guid as GUID; // maybe add validation that the parameter is an actual guid ?
}

export interface TodoEntry {
	id: GUID;
	title: string;
	createDate: Date;
	dueDate: Date;
	status: number;
}
