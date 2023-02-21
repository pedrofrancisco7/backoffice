import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { map } from 'rxjs';
import { BackofficeService } from 'src/app/services/backoffice-service.service';
import { DepartamentoModel } from 'src/models/departamentoModel';
import { PessoaModel } from 'src/models/pessoaModel';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.scss']
})
export class DepartamentosComponent implements OnInit {
  exibirFormularioDpto = true;
  formularioDpto: FormGroup | any;
  responsaveis!: PessoaModel[];
  sucesso = false;
  erro = false;

  constructor(private formBuilder: FormBuilder, private bkoService: BackofficeService, private spinner: NgxSpinnerService) {


  }

  ngOnInit() {
    this.formularioDpto = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(3)]],
      responsavel: ['', Validators.required]
    });

    this.buscaResponsavel();
  }

  buscaResponsavel() {
    let pessoa = [] as PessoaModel[];
    this.bkoService.buscarResponsavel().pipe(map((data: any) => {
      data.forEach((element: PessoaModel) => {
        pessoa.push(element)
      });
    })).subscribe(() => { this.responsaveis = pessoa });
  }

  onSelect(pessoa: string) {

  }

  onSubmit() {

    this.spinner.show();

    alert('enviando');

    let deptoModel = {} as DepartamentoModel;
    deptoModel.nome = this.formularioDpto.controls.nome.value;

    deptoModel.idResponsavel = this.formularioDpto.controls.responsavel.value;

    return this.bkoService.saveDepartamento(deptoModel).pipe(map((data: any) => {
      return data;
    })).subscribe(() => {
      this.spinner.hide();
      this.sucesso = true;
      this.formularioDpto.reset();

      setInterval(() => {
        this.sucesso = false;
      }, 3000);

    }, error => {
      this.spinner.hide();
      this.erro = true;
      setInterval(() => {
        this.erro = false;
      }, 5000);


    });

  }


}
