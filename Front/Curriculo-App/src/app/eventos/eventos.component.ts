import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { response } from 'express';
import { error } from 'console';

@Component({
  selector: 'app-eventos',
  standalone: true,
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  imports: [CommonModule, HttpClientModule]
})
export class EventosComponent {
  
  // EX1:
  // public eventos: any = [
  //   {
  //     Tema: 'Angular',
  //     Local: 'Rio de Janeiro'
  //   },
  //   {
  //     Tema: 'C#',
  //     Local: 'São Paulo'
  //   },
  //   {
  //     Tema: 'SQL',
  //     Local: 'Belo Horizonte'
  //   }
  // ];

  public eventos: any;

  /** 
   * @param http 
   * O código constructor(private http: HttpClient) { } no Angular serve para injetar a dependência HttpClient no componente ou serviço.
   *  Ao fazer isso, você está dizendo ao Angular que o seu componente precisa de uma instância do serviço HttpClient para funcionar.

    Aqui está um resumo do que isso faz:

    Injeção de Dependência: HttpClient é injetado no construtor do componente, tornando-o disponível para ser utilizado em qualquer 
    método dentro do componente.

    Requisições HTTP: Com o HttpClient injetado, você pode fazer requisições HTTP para obter dados de APIs, enviar dados para um
    servidor, etc.

    Manutenção de Código: Facilita a manutenção e testes, já que você pode substituir HttpClient por um serviço mockado durante os testes.

    Aqui está um exemplo de uso do HttpClient para fazer uma requisição GET:

    typescript
    import { Component, OnInit } from '@angular/core';
    import { HttpClient } from '@angular/common/http';

    @Component({
      selector: 'app-eventos',
      standalone: true,
      templateUrl: './eventos.component.html',
      styleUrls: ['./eventos.component.scss'],
      imports: [CommonModule, HttpClientModule]
    })
    export class EventosComponent implements OnInit {

      public eventos: any[];

      constructor(private http: HttpClient) { }

      ngOnInit() {
        this.http.get<any[]>('https://api.meuservidor.com/eventos')
          .subscribe(data => {
            this.eventos = data;
          });
      }
    }
    
    Neste exemplo, no método ngOnInit, a função this.http.get faz uma requisição HTTP GET para a URL fornecida. 
    Quando a resposta chega, os dados são atribuídos à propriedade eventos.
   */

  //constructor() { }
  constructor(private http: HttpClient) { }

  ngOnInit() :void {
    // Aqui você pode fazer uma requisição HTTP usando o HttpClient, se necessário
    // this.http.get('url').subscribe(data => console.log(data));
  
    this.getEventos();
  }
    
  // EX2:
  public getEventos(): void {
    
    // Ex3:
    this.http.get<any[]>('https://localhost:5048/api/Candidato')
      .subscribe(response => this.eventos = response,
        error => console.log(error)    
    );

    // this.eventos = [
    //   {
    //     Tema: 'Angular',
    //     Local: 'Rio de Janeiro'
    //   },
    //   {
    //     Tema: 'C#',
    //     Local: 'São Paulo'
    //   },
    //   {
    //     Tema: 'SQL',
    //     Local: 'Belo Horizonte'
    //   }
    // ];
  }

}
