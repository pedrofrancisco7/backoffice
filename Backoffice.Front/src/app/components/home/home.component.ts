import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { BackofficeService } from '../../services/backoffice-service.service';
import { map } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { PessoaModel } from 'src/models/pessoaModel';
import { CepModel } from 'src/models/cepModel';
import { QualificacaoModel } from 'src/models/qualificacaoModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    trigger('mensagemAnimacao', [
      state('visivel', style({
        opacity: 1
      })),
      state('escondido', style({
        opacity: 0,
        display: 'none'
      })),
      transition('visivel => escondido', [
        animate('2s')
      ]),
      transition('escondido => visivel', [
        animate('5s')
      ])
    ])
  ]
})


export class HomeComponent implements OnInit {
  formulario: FormGroup | any;
  exibirMensagem = true;
  exibirFormulario = true;
  mudarTipoPessoa = false;
  pessoa: any = "Física";
  endereco!: any;
  pessoaModel!: PessoaModel;
  qualificacaoId!: string;
  sucesso = false;
  erro = false;


  tiposPessoa: string[] = ['Física', 'Jurídica'];
  tipoQualificacao!: QualificacaoModel[];

  constructor(private formBuilder: FormBuilder, private bkoService: BackofficeService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      tipoPessoa: ['', Validators.required],
      documento: ['', [Validators.required, Validators.minLength(11)]],
      qualificacao: ['', Validators.required],
      nome: ['', [Validators.required, Validators.minLength(3)]],
      apelido: [''],
      cep: ['', [Validators.required, Validators.minLength(8)]],
      logradouro: [{ value: '', disabled: true }, Validators.required],
      num: ['', Validators.required],
      complemento: [''],
      bairro: [{ value: '', disabled: true }, Validators.required],
      localidade: [{ value: '', disabled: true }, Validators.required],
      uf: [{ value: '', disabled: true }, Validators.required],
    });

    this.formulario.get("tipoPessoa").setValue('Física');
    this.buscarQualificacoes();
  }

  buscarQualificacoes() {

    let tpQualificacao = [] as QualificacaoModel[];
    this.bkoService.buscarQualificacoes().pipe(map((data: any) => {
      data.forEach((element: any) => {
        tpQualificacao.push(element);
      });
    })).subscribe(() => { this.tipoQualificacao = tpQualificacao; });

  }

  onSubmit() {

    if (this.formulario.valid) {

      this.spinner.show();

      alert('enviando');

      let pessoaMdl = {} as PessoaModel;
      pessoaMdl.endereco = {} as CepModel;
      pessoaMdl.qualificacoes = [];

      pessoaMdl.tipoPessoa = this.formulario.controls.tipoPessoa.value;
      pessoaMdl.documento = this.formulario.controls.documento.value;
      pessoaMdl.nome = this.formulario.controls.nome.value;
      pessoaMdl.apelido = this.formulario.controls.apelido.value;
      pessoaMdl.cep = this.formulario.controls.cep.value;
      pessoaMdl.endereco.cep = this.formulario.controls.cep.value;
      pessoaMdl.endereco.logradouro = this.formulario.controls.logradouro.value + ' ' + this.formulario.controls.num.value;
      pessoaMdl.endereco.complemento = this.formulario.controls.complemento.value;
      pessoaMdl.endereco.bairro = this.formulario.controls.bairro.value;
      pessoaMdl.endereco.localidade = this.formulario.controls.localidade.value;
      pessoaMdl.endereco.uf = this.formulario.controls.uf.value;
      pessoaMdl.qualificacoes.push(this.qualificacaoId);

      return this.bkoService.enviarDados(pessoaMdl).pipe(map((data: any) => {
        return data;
      })).subscribe(() => {
        this.spinner.hide();
        this.sucesso = true;
        this.formulario.reset();
        
        setInterval(() => {
          this.sucesso = false;
        }, 3000);

      }, error => {
        this.spinner.hide();
        this.erro = true;

        setInterval(() => {
          this.erro = false;
        }, 5000);
        
        console.log(error.error)
      });

    }
    else {
      return null;
    }
  }

  exibirForm() {
    this.exibirMensagem = false;
    setTimeout(() => this.exibirFormulario = true, 2000);
  }

  onSelect(opcao: string) {

    if (opcao === "Física") {
      this.mudarTipoPessoa = false;
    } else {
      this.mudarTipoPessoa = true;
    }
  }

  setQualificacao(opcao: any) {
    console.log(opcao);
    this.qualificacaoId = opcao;
  }

  buscaCep(cep: string) {
    this.formulario.setErrors({ 'invalid': true });

    if (cep.length > 7) {
      this.spinner.show();

      return this.bkoService.getEndereco(cep).pipe(map((data: any) => {

        if (data.erro == "true") {
          alert('Cep Inválido');
          this.formulario.setErrors({ 'invalid': true });

          this.formulario.get("cep").setValue();
          this.formulario.get("logradouro").setValue();
          this.formulario.get("bairro").setValue();
          this.formulario.get("localidade").setValue();
          this.formulario.get("uf").setValue();
          this.spinner.hide();

        }
        else {
          this.formulario.get("logradouro").setValue(data.logradouro);
          this.formulario.get("bairro").setValue(data.bairro);
          this.formulario.get("localidade").setValue(data.localidade);
          this.formulario.get("uf").setValue(data.uf);

          this.spinner.hide();
        }

      })).subscribe();
    } else {
      return this.endereco;
    }
  }

}
