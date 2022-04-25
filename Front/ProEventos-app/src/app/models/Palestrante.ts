import { RedeSocial } from "./RedeSocial";
//aula 78
export interface Palestrante {
   id:number;
   nome:string;
   descricao:string;
   imagemUrl:string;
   telefone:string;
   email:string;
   redesSociais:RedeSocial[];
   palestrantesEventos:Palestrante[];
}
