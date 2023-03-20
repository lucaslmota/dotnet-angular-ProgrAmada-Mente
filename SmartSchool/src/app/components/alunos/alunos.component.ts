import { Component, OnDestroy, OnInit, TemplateRef} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Aluno } from 'src/app/models/Aluno';
import { AlunoService } from './aluno.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit{

  public titulo = 'Alunos';
  public alunoSelecioinado: Aluno;
  public alunoForm: FormGroup;
  public modalRef: BsModalRef;
  public modo = 'post';

  public alunos: Aluno[];



  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(
        template,
        Object.assign({}, {class: 'modal-lg'})
      );
  }


  constructor(
    private fb: FormBuilder,
    private modalService: BsModalService,
    private alunoService: AlunoService){
    this.criarForm();
  }

  ngOnInit(){
    this.carregaAlunos();
  }

  carregaAlunos(){
    this.alunoService.getAll().subscribe(
      (alunos: Aluno[]) => {
        this.alunos = alunos;
      },
      (erro: any) => {
        console.error(erro);
      }
    )
  }

  criarForm(){
    this.alunoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  salvarAluno(aluno: Aluno){
    (aluno.id === 0) ? this.modo = 'post' : this.modo = 'put';
    this.alunoService[this.modo](aluno).subscribe(
      (alunoRetorno: Aluno) => {
        console.log(alunoRetorno);
        this.carregaAlunos();
      },
      (erro) => {
        console.log(erro)
      }
    );
  }

  alunoSubmit(){
    this.salvarAluno(this.alunoForm.value);
  }


  alunoSlected(aluno: Aluno){
    this.alunoSelecioinado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  alunoNovo(){
    this.alunoSelecioinado = new Aluno();
    this.alunoForm.patchValue(this.alunoSelecioinado);
  }

  deletarAluno(id: number){
    this.alunoService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregaAlunos();
      },
      (erro) => {
        console.error(erro);
      }
    );
  }

  voltar(){
    this.alunoSelecioinado = null;
  }
}
