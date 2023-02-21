import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/assets/environment';
import { map, Observable } from 'rxjs';
import { PessoaModel } from 'src/models/pessoaModel';
import { DepartamentoModel } from 'src/models/departamentoModel';


@Injectable({
  providedIn: 'root'
})
export class BackofficeService {
  apiUrl = environment.apiURL;
  constructor(private http: HttpClient) { }

  getEndereco(cep: string) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    return this.http.post(`${this.apiUrl}/Endereco/GetEndereco`, JSON.stringify(cep), httpOptions);
  }

  enviarDados(dados: PessoaModel): Observable<PessoaModel> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    return this.http.post<PessoaModel>(`${this.apiUrl}/Pessoa`, dados, httpOptions).pipe(
      map(response => {
        console.log(response);
        return response;
      }));
  }

  buscarQualificacoes() {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.get(`${this.apiUrl}/Qualificacao`, httpOptions);
  }

  buscarResponsavel() {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.get(`${this.apiUrl}/Pessoa/GetResponsavel`, httpOptions);
  }

  saveDepartamento(dados: DepartamentoModel): Observable<DepartamentoModel> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    return this.http.post<DepartamentoModel>(`${this.apiUrl}/Departamento/SaveDepartamento`, dados, httpOptions).pipe(
      map(response => {
        console.log(response);
        return response;
      }));
  }

}
