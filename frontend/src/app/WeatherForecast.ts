import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  id: string;
  nombre: string;
  estado: string;
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    public forecasts: WeatherForecast[] = [];

    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.getForecasts();
    }

  getForecasts() {
    this.http.get<WeatherForecast[]>('http://localhost:5038/api/Marca').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }


    title = 'frontend';
}
