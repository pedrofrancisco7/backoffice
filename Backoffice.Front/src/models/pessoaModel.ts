import { CepModel } from "./cepModel";

export interface PessoaModel {
    id: string;
    tipoPessoa: string;
    documento: string;
    nome: string;
    apelido: string;
    idDepartamento: string;
    cep: string;
    qualificacoes: string[];
    endereco: CepModel;
}

