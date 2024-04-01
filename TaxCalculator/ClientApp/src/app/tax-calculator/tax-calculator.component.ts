import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface TaxCalculationResult {
  grossAnnualSalary: number;
  netAnnualSalary: number;
  annualTaxPaid: number;
}

@Component({
  selector: 'app-tax-calculator',
  templateUrl: './tax-calculator.component.html',
  styleUrls: ['./tax-calculator.component.css']
})
export class TaxCalculatorComponent {
  grossSalary: number = 0;
  taxCalculationResult: TaxCalculationResult | undefined;

  constructor(private http: HttpClient) { }

  calculateTax(): void {
    const url = `https://localhost:7077/api/tax/calculate`;
    const requestBody = this.grossSalary;

    this.http.post<TaxCalculationResult>(url, requestBody).subscribe(result => {
      this.taxCalculationResult = result;
    });
  }
}
