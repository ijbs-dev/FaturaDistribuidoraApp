import { Component, OnInit } from '@angular/core';
import { FaturamentoService } from '../../services/faturamento.service';
import { Faturamento } from '../../models/faturamento.model';

@Component({
  selector: 'app-faturamento-resumo',
  templateUrl: './faturamento-resumo.component.html',
  styleUrls: ['./faturamento-resumo.component.css']
})
export class FaturamentoResumoComponent implements OnInit {

  faturamentos: Faturamento[] = [];
  novoFaturamento: Faturamento = { id: 0, data: new Date(), valor: 0 }; // Ajustado para "data"
  erro!: string;
  hasData: boolean = false;
  maiorValor!: number;
  menorValor!: number;
  diasAcimaDaMedia!: number;

  constructor(private faturamentoService: FaturamentoService) { }

  ngOnInit(): void {
    this.buscarFaturamentos();
  }

  // Função para buscar todos os faturamentos
  buscarFaturamentos(): void {
    this.faturamentoService.getFaturamentoResumo().subscribe(
      data => {
        console.log('Dados recebidos da API:', data);
        this.faturamentos = data.faturamentos;
        this.menorValor = data.menorValor;
        this.maiorValor = data.maiorValor;
        this.diasAcimaDaMedia = data.diasAcimaDaMedia;
        this.hasData = true;
      },
      error => {
        this.erro = error;
        this.hasData = false;
      }
    );
  }

  // Adicionar novo faturamento
  adicionarFaturamento(): void {
    // Converter a data recebida do input para um objeto Date
    const dataFormatada = new Date(this.novoFaturamento.data);

    if (isNaN(dataFormatada.getTime())) {
      console.error('Data inválida.');
      return;
    }

    this.novoFaturamento.data = dataFormatada;

    this.faturamentoService.createFaturamento(this.novoFaturamento).subscribe(
      response => {
        this.buscarFaturamentos();  // recarregar a tabela
        this.novoFaturamento = { id: 0, data: new Date(), valor: 0 };  // resetar o formulário
      },
      error => {
        console.error('Erro ao adicionar faturamento:', error);
      }
    );
  }


  // Alterar faturamento
  alterarFaturamento(faturamento: Faturamento): void {
    const novoValor = prompt('Novo valor:', faturamento.valor.toString());
    if (novoValor) {
      faturamento.valor = parseFloat(novoValor);
      this.faturamentoService.updateFaturamento(faturamento.id, faturamento).subscribe(
        response => this.buscarFaturamentos(),
        error => console.error('Erro ao alterar faturamento:', error)
      );
    }
  }

  // Confirmar remoção
  confirmarRemocao(id: number): void {
    const confirmar = confirm('Deseja realmente remover esse faturamento?');
    if (confirmar) {
      this.faturamentoService.deleteFaturamento(id).subscribe(
        response => this.buscarFaturamentos(),
        error => console.error('Erro ao remover faturamento:', error)
      );
    }
  }
}
