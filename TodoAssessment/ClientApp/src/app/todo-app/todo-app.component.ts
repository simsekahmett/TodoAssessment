
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-todo-app',
  templateUrl: './todo-app.component.html'
})
export class TodoAppComponent {
  public forecasts: TodoEntry[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TodoEntry[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface TodoEntry {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

