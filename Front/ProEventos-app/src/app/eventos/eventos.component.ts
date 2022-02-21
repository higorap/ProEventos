import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos : any  =[] ;// para que possua elementos para aparecer nenhum encontrad
  public eventosFiltrados : any =[];

  private _filtroLista: string = '';

  widthImg : number =150;
  margImg: number=2;
  exibirImg :boolean = true;



   public get filtroLista(){
     return this._filtroLista
   }

   public set filtroLista(value:string){
      this._filtroLista = value
      this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista):this.eventos;
   }

   filtrarEventos(filtrarPor:String):any{
    filtrarPor= filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      //     tem outra definicao aula 48 para abreviar (deixei assim pra poder adicionar mais propriedades pra busca)
      (      evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
                             evento.local.toLocaleLowerCase().indexOf(filtrarPor)!== -1 
    )
   }
  constructor(private http: HttpClient ) { }

  ngOnInit(): void {
    this.getEventos();
  }
  alterarImgaem() {
    this.exibirImg = !this.exibirImg;
  }

  public getEventos():void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response=> {this.eventos=response
                  this.eventosFiltrados =this.eventos},
      error => console.log(error)
    );

  }
}

