import { Component } from '@angular/core';
import { ConferenceData } from '../../providers/conference-data';

@Component({
  selector: 'page-product-list',
  templateUrl: 'product-list.html',
  styleUrls: ['./product-list.scss'],
})
export class ProductListPage {
  products: any[] = [];

  constructor(public confData: ConferenceData) {}

  ionViewDidEnter() {
    this.confData.getProducts().subscribe((products: any[]) => {
      this.products = products;
    });
  }
}
