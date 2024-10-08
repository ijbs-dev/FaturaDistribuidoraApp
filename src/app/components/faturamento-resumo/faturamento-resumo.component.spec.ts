import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FaturamentoResumoComponent } from './faturamento-resumo.component';

describe('FaturamentoResumoComponent', () => {
  let component: FaturamentoResumoComponent;
  let fixture: ComponentFixture<FaturamentoResumoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FaturamentoResumoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FaturamentoResumoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
