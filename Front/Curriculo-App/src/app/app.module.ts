import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule //
  ],
  providers: []
  //bootstrap: [AppComponent]
})
export class AppModule { }

/*
  O BrowserAnimationsModule faz parte do Angular e é utilizado para habilitar animações no navegador. Ele é essencial quando você deseja usar animações no Angular, especialmente se você estiver utilizando a biblioteca Angular Material, que depende de animações para alguns de seus componentes funcionarem corretamente.

  Ao importar o BrowserAnimationsModule no seu projeto, você está dizendo ao Angular que ele deve incluir e usar as capacidades de animação do Angular no navegador.

  Aqui está um exemplo de como incluir o BrowserAnimationsModule no seu módulo principal (AppModule):

  typescript
  import { BrowserModule } from '@angular/platform-browser';
  import { NgModule } from '@angular/core';
  import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Importe o módulo

  import { AppComponent } from './app.component';

  @NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule // Adicione o módulo aqui
  ],
  providers: [],
  bootstrap: [AppComponent]
  })
  export class AppModule { }
  Ao fazer isso, você poderá usar as animações Angular nos seus componentes e ter acesso a todas as funcionalidades de animação que a biblioteca oferece.
*/