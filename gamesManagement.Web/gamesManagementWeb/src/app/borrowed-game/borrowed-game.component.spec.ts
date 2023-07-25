import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BorrowedGameComponent } from './borrowed-game.component';

describe('BorrowedGameComponent', () => {
  let component: BorrowedGameComponent;
  let fixture: ComponentFixture<BorrowedGameComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BorrowedGameComponent]
    });
    fixture = TestBed.createComponent(BorrowedGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
