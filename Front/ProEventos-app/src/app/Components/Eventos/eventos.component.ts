import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/Service/evento.service';



@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos : Evento[]  =[] ;// para que possua elementos para aparecer nenhum encontrad
  public eventosFiltrados : Evento[] =[];

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

   filtrarEventos(filtrarPor:String):Evento[] {
    filtrarPor= filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      //     tem outra definicao aula 48 para abreviar (deixei assim pra poder adicionar mais propriedades pra busca)
      (      evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
                             evento.local.toLocaleLowerCase().indexOf(filtrarPor)!== -1
    )
   }
  constructor(
    private modalService: BsModalService,
    private eventoSevice: EventoService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }
 public alterarImagem ():void {
    this.exibirImg = !this.exibirImg;
  }

  public getEventos():void{
    this.eventoSevice.getEvento().subscribe({
    next:(eventos: Evento[])=>      {
      this.eventos=eventos;
      this.eventosFiltrados =this.eventos;},
    error :(error :any)=>{
      this.spinner.hide();
      this.toastr.error('Erro ao carregar','Error 404!')
    },
    complete:() =>this.spinner.hide()

   } );

  }
  openModal(template: TemplateRef<any>):void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {

    this.modalRef?.hide();
    this.toastr.success('Sucesso ao deletar o evento', 'Deletado!!!'); /**npm i ngx-spinner@11.0.2 */
  }

  decline(): void {

    this.modalRef?.hide();
  }
}

