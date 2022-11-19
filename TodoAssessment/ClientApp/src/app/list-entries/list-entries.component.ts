import { Component, Inject, LOCALE_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TodoEntry } from '../interfaces/TodoEntry';
import { formatDate } from '@angular/common';


@Component({
	selector: 'app-list-entries',
	templateUrl: './list-entries.component.html'
})
export class ListEntriesComponent {
	public entries: TodoEntry[] = [];
	private httpClient: HttpClient;
	private baseUrl: string;

	getFormattedDateText(dueDate: string) {
		return formatDate(dueDate, 'dd-MM-yyyy HH:mm', this.locale);
	}

	getStatusText(status: number) {
		switch (status) {
			case 0:
				return "Pending";
			case 1:
				return "Overdue";
			case 2:
				return "Done";
			default:
				return "N/A";
		}
	}

	radioButtonGetAllEvent(event: any) {
		console.log(event);
		this.httpClient.get<TodoEntry[]>(this.baseUrl + 'todo/all').subscribe(result => {
			this.entries = result;
		}, error => console.error(error));
	}

	radioButtonGetPendingEvent(event: any) {
		this.httpClient.get<TodoEntry[]>(this.baseUrl + 'todo/status?status=0').subscribe(result => {
			this.entries = result;
		}, error => console.error(error));
	}

	radioButtonGetOverDueEvent(event: any) {
		this.httpClient.get<TodoEntry[]>(this.baseUrl + 'todo/status?status=1').subscribe(result => {
			this.entries = result;
		}, error => console.error(error));
	}

	radioButtonGetDoneEvent(event: any) {
		this.httpClient.get<TodoEntry[]>(this.baseUrl + 'todo/status?status=2').subscribe(result => {
			this.entries = result;
		}, error => console.error(error));
	}

	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject(LOCALE_ID) private locale: string) {
		this.httpClient = http;
		this.baseUrl = baseUrl;
		this.httpClient.get<TodoEntry[]>(this.baseUrl + 'todo/all').subscribe(result => {
			this.entries = result;
		}, error => console.error(error));
	}
}

