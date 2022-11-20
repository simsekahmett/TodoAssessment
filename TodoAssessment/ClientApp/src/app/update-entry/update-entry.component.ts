import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, LOCALE_ID } from '@angular/core';
import { TodoEntry } from '../interfaces/TodoEntry';

@Component({
	selector: 'app-update-entry',
	templateUrl: './update-entry.component.html',
})
export class UpdateEntryComponent {
	public entries: TodoEntry[] = [];
	public selectedEntry!: TodoEntry;
	public selectedStatus!: number;
	public resultText: string = "";
	public selectedDate: string = "";

	private httpClient: HttpClient;
	private baseUrl: string;

	onChange(entry: any) {
		this.selectedEntry = entry;
		this.selectedStatus = this.selectedEntry.status;
		this.selectedDate = formatDate(this.selectedEntry.dueDate, 'yyyy-MM-ddTHH:mm', this.locale);
	}

	updateTodoEntry() {
		let entry = {} as TodoEntry;

		entry.id = this.selectedEntry.id;
		entry.title = this.selectedEntry.title;
		entry.createDate = this.selectedEntry.createDate;
		entry.status = this.selectedStatus;
		entry.dueDate = formatDate(this.selectedDate, 'yyyy-MM-ddTHH:mm', this.locale);

		this.httpClient.patch(this.baseUrl + 'todo/update', entry, { observe: 'response' }).subscribe(result => {
			if (result.status == 200)
				this.resultText = "Entry updated successfuly: " + this.selectedEntry.title;
			else if (result.status == 500)
				this.resultText = "Entry updating failed";

		}, error => console.error(error));
	}

	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject(LOCALE_ID) private locale: string) {
		this.httpClient = http;
		this.baseUrl = baseUrl;

		this.httpClient.get<TodoEntry[]>(this.baseUrl + 'todo/all').subscribe(result => {
			this.entries = result;


			if (this.entries.length > 0) {
				this.selectedEntry = this.entries[0];
				this.selectedDate = formatDate(this.entries[0].dueDate, 'yyyy-MM-ddTHH:mm', this.locale);
				this.selectedStatus = this.entries[0].status;
			}
		}, error => console.error(error));

	}
}