import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { ProductListPage } from './product-list';
import { ProductListPageRoutingModule } from './product-list-routing.module';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    ProductListPageRoutingModule
  ],
  declarations: [ProductListPage],
})
export class ProductListModule {}
