import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public swaggerUrl: string = "";

  constructor(@Inject('BASE_URL') baseUrl: string,) {
    this.swaggerUrl = "https://localhost:7010/docs/index.html";
    console.log(this.swaggerUrl);
  }
}

