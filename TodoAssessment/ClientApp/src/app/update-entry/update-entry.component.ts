import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { TodoEntry } from '../interfaces/TodoEntry';

@Component({
	selector: 'app-update-entry',
	templateUrl: './update-entry.component.html',
})
export class UpdateEntryComponent {
	public entries: TodoEntry[] = [];
	public selectedEntry!: TodoEntry;
	public selectedStatus!: number;

	onChange(entry: any) {
		console.log(entry);
		this.selectedEntry = entry;
		this.selectedStatus = this.selectedEntry.status;
	}

	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
		http.get<TodoEntry[]>(baseUrl + 'todo/all').subscribe(result => {
			this.entries = result;


			if (this.entries.length > 0)
				this.selectedEntry = this.entries[0];
		}, error => console.error(error));

	}
}