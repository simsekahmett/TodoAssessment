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


	getFormattedDateText(dueDate: Date) {
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

	constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, @Inject(LOCALE_ID) private locale: string) {
		http.get<TodoEntry[]>(baseUrl + 'todo/all').subscribe(result => {
			this.entries = result;
		}, error => console.error(error));
	}
}

