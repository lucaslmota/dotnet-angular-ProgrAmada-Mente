import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Professor } from 'src/app/models/Professor';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  baseUrl = `${environment.mainUrlAPI}/api/professor`;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Professor[]>{
    return this.http.get<Professor[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Professor>{
    return this.http.get<Professor>(`${this.baseUrl}/${id}`);
  }

  getByIdAluno(id: number): Observable<Professor>{
    return this.http.get<Professor>(`${this.baseUrl}/ByAluno/${id}`);
  }

  post(professor: Professor){
    return this.http.post(`${this.baseUrl}`, professor);
  }

  put(professor: Professor){
    return this.http.put(`${this.baseUrl}/${professor.id}`, professor);
  }

  delete(id: number){
    return this.http.delete(`${this.delete}/${id}`);
  }
}
