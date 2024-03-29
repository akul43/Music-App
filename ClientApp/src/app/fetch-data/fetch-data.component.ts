import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public music: Music[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Music[]>(baseUrl + 'api/Songs1').subscribe(result => {
      this.music = result;
    }, error => console.error(error));
  }
}

interface Music {
  title: string;
  releaseDate: string;
  artist: string;
  genre: string;
  labelName: string;
}
