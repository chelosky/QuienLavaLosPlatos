import { Component, OnInit } from '@angular/core';
import { MainService } from '../../services/main.service';
import { Competitor } from '../../models/competitor';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(
    public mainServices: MainService
  ) { }

  ngOnInit(): void {
    this.mainServices.obtenerCompetidores();
  }

  reiniciar(){
    this.mainServices.reiniciarGanador().subscribe((response: any) => {
      console.log(response);
    }, (error: any) => {
      console.log(error);
    }, () => {
      this.mainServices.obtenerCompetidores();
    });
  }

  ganador(competidor: Competitor){
    this.mainServices.registrarGanador(competidor).subscribe((response: any) => {
      console.log(response);
    }, (error: any) => {
      console.log(error);
    }, () => {
      this.mainServices.obtenerCompetidores();
    });
  }

}
