import { HttpClient } from '@angular/common/http';
import { Component, Inject, LOCALE_ID } from '@angular/core';
import { TodoEntry } from '../interfaces/TodoEntry';
import { Guid } from "guid-typescript";
import { formatDate } from '@angular/common';

@Component({
	selector: 'app-create-entry',
	templateUrl: './create-entry.component.html',
})
export class CreateEntryComponent {
	public title: string = "";
	public dueDate: string = "";
	public resultText: string = "";

	private httpClient: HttpClient;
	private baseUrl: string;

	createTodoEntry() {
		let entry = {} as TodoEntry;
		var today = new Date();
		entry.title = this.title;
		entry.id = Guid.create().toString();
		entry.createDate = formatDate(today, 'yyyy-MM-ddTHH:mm:ss', this.locale);
		entry.dueDate = formatDate(this.dueDate, 'yyyy-MM-ddTHH:mm:ss', this.locale);
		entry.status = 0;

		this.httpClient.post(this.baseUrl + 'todo/add', entry, { observe: 'response' }).subscribe(result => {
			if (result.status == 200)
				this.resultText = "Entry added successfuly: " + entry.title;
			else if (result.status == 500)
				this.resultText = "Entry adding failed";

		}, error => console.error(error));
	}

	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject(LOCALE_ID) private locale: string) {
		this.httpClient = http;
		this.baseUrl = baseUrl;
		// http.get<TodoEntry[]>(baseUrl + 'todo/all',).subscribe(result => {
		// 	this.entries = result;
		// }, error => console.error(error));
	}
}

