import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductDetailPage } from './product-detail';
import { ProductDetailPageRoutingModule } from './product-detail-routing.module';
import { IonicModule } from '@ionic/angular';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    ProductDetailPageRoutingModule
  ],
  declarations: [
    ProductDetailPage,
  ]
})
export class ProductDetailModule { }
