import { Component, OnInit } from '@angular/core';
import { Competitor } from '../../models/competitor';
import { MainService } from '../../services/main.service';
import { interval } from 'rxjs';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  basePath = '../../../assets/Images/';
  ganadorAnterior: Competitor = null;
  ganadorActual: Competitor = null;
  seleccionandoGanador = false;
  ganadorSeleccionado = false;
  constructor(
    public mainServices: MainService
  ) { }

  ngOnInit(): void {
    this.setUpInformation();
  }

  setUpInformation(){
    this.mainServices.obtenerCompetidores();
    this.mainServices.obtenerGanadorAnterior().subscribe((response: any) => {
      if (response.status) {
        this.ganadorAnterior = response.data;
      } else {
        this.ganadorAnterior = null;
        console.log(response.info);
      }
    }, (error: any) => {
      this.ganadorAnterior = null;
      console.log(error);
    });
  }

  seleccionarGanador(){
    this.seleccionandoGanador = true;
    setTimeout( () => {
      this.terminoProcesoSeleccion();
    }, 1000);
  }

  terminoProcesoSeleccion(){
    this.seleccionandoGanador = false;
    this.ganadorActual = this.mainServices.generarGanadorActual();
    this.mainServices.registrarGanador(this.ganadorActual).subscribe((response: any) => {
      console.log(response);
    }, (error: any) => {
      console.log(error);
    }, () => {
      this.celebracionGanador();
    });
  }

  celebracionGanador(){
    this.ganadorSeleccionado = true;
    const duration = (Date.now() + 3000);
    let interval = setInterval(() => {
      let timeLeft = duration - Date.now();
      if (timeLeft <= 0){
        return clearInterval(interval);
      }
      this.shoot();
      this.shoot();
    }, 200);
  }

  shoot() {
    try {
      this.confetti({
        angle: this.random(60, 120),
        spread: this.random(10, 50),
        particleCount: this.random(40, 70),
        origin: {
          x: this.random(0.2, 0.8),
          y: Math.random() + 0.6 }
      });
    } catch (e) {
      // noop, confettijs may not be loaded yet
    }
  }

  random(min: number, max: number) {
    return Math.random() * (max - min) + min;
  }

  confetti(args: any) {
    // tslint:disable-next-line: no-string-literal
    return window['confetti'].apply(this, arguments);
  }
}
