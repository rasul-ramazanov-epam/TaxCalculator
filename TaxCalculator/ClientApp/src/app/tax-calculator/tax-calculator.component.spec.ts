import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TaxCalculatorComponent } from './tax-calculator.component';

describe('TaxCalculatorComponent', () => {
  let component: TaxCalculatorComponent;
  let fixture: ComponentFixture<TaxCalculatorComponent>;
  let httpMock: HttpTestingController;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, FormsModule],
      declarations: [TaxCalculatorComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(TaxCalculatorComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  }));

  afterEach(() => {
    httpMock.verify();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should calculate tax correctly', () => {
    const testValue = 50000;
    const expectedResponse = { grossAnnualSalary: testValue, netAnnualSalary: 42500, annualTaxPaid: 7500 };

    component.grossSalary = testValue;
    component.calculateTax();

    const request = httpMock.expectOne('https://localhost:7077/api/tax/calculate');
    expect(request.request.method).toBe('POST');
    expect(request.request.body).toBe(testValue);

    request.flush(expectedResponse);

    expect(component.taxCalculationResult).toEqual(expectedResponse);
  });
});
