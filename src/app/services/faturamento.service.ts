import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

// importando Models/Faturamento.cs
import { Faturamento } from '../models/faturamento.model';

@Injectable({
  providedIn: 'root'
})
export class FaturamentoService {
  private apiUrl = 'http://localhost:5068/api/faturamento';
  constructor(private http: HttpClient) { }

  // GET Resumo e lista de faturamentos
  getFaturamentoResumo(): Observable<any> {
    return this.http.get(this.apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // GET um único faturamento
  getFaturamento(id: number): Observable<Faturamento> {
    return this.http.get<Faturamento>(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  // POST criar um novo faturamento
  createFaturamento(faturamento: Faturamento): Observable<Faturamento> {
    return this.http.post<Faturamento>(this.apiUrl, faturamento).pipe(
      catchError(this.handleError)
    );
  }

  // PUT atualizar um faturamento
  updateFaturamento(id: number, faturamento: Faturamento): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, faturamento).pipe(
      catchError(this.handleError)
    );
  }

  // DELETE remover um faturamento
  deleteFaturamento(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  // Tratamento de erro
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('Ocorreu um erro:', error.error.message);
    } else {
      console.error(
        `Código do erro ${error.status}, ` +
        `Corpo do erro: ${error.error}`);
    }
    return throwError('Algo deu errado; por favor, tente novamente mais tarde.');
  }
}
