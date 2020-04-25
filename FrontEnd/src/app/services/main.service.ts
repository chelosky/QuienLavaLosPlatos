import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Competitor } from '../models/competitor';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  competitorList: Competitor [] = [];
  private URL_API = environment.urlApi;
  constructor(
    private http: HttpClient
  ) { }

  obtenerCompetidores() {
    this.http.get(this.URL_API + 'Competitor/Todos').subscribe((response: any) => {
      if (response.status){
        this.competitorList = response.data;
      }else{
        console.log(response.info);
      }
    }, (error: any) => {
      console.log(error);
    }, () => {
      console.log(this.competitorList);
    });
  }

  registrarGanador(ganador: Competitor){
    console.log(ganador);
    return this.http.post(this.URL_API + 'Competitor/Ganador',
    { ...ganador });
  }

  obtenerGanadorAnterior(){
    return this.http.get(this.URL_API + 'Competitor/GanadorAnterior');
  }

  generarGanadorActual(): Competitor{
     return this.competitorList[Math.floor(Math.random() * this.competitorList.length)];
  }

  reiniciarGanador(){
    return this.http.post(this.URL_API + 'Competitor/Reiniciar',
    {});
  }
}
