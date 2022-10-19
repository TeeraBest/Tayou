import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConferenceData } from '../../providers/conference-data';
import { ActionSheetController } from '@ionic/angular';
import { InAppBrowser } from '@ionic-native/in-app-browser/ngx';

@Component({
  selector: 'page-product-detail',
  templateUrl: 'product-detail.html',
  styleUrls: ['./product-detail.scss'],
})
export class ProductDetailPage {
  product: any;

  constructor(
    private dataProvider: ConferenceData,
    private route: ActivatedRoute,
    public actionSheetCtrl: ActionSheetController,
    public confData: ConferenceData,
    public inAppBrowser: InAppBrowser,
  ) {}

  ionViewWillEnter() {
    this.dataProvider.load().subscribe((data: any) => {
      const productId = this.route.snapshot.paramMap.get('productId');
      if (data && data.products) {
        for (const product of data.products) {
          if (product && product.id === productId) {
            this.product = product;
            break;
          }
        }
      }
    });
  }

  openExternalUrl(url: string) {
    this.inAppBrowser.create(
      url,
      '_blank'
    );
  }

  async openProductShare(product: any) {
    const actionSheet = await this.actionSheetCtrl.create({
      header: 'Share ' + product.name,
      buttons: [
        {
          text: 'Copy Link',
          handler: () => {
            console.log(
              'Copy link clicked on https://twitter.com/' + product.twitter
            );
            if (
              (window as any).cordova &&
              (window as any).cordova.plugins.clipboard
            ) {
              (window as any).cordova.plugins.clipboard.copy(
                'https://twitter.com/' + product.twitter
              );
            }
          }
        },
        {
          text: 'Share via ...'
        },
        {
          text: 'Cancel',
          role: 'cancel'
        }
      ]
    });

    await actionSheet.present();
  }

  async openContact(product: any) {
    const mode = 'ios'; // this.config.get('mode');

    const actionSheet = await this.actionSheetCtrl.create({
      header: 'Contact ' + product.name,
      buttons: [
        {
          text: `Email ( ${product.email} )`,
          icon: mode !== 'ios' ? 'mail' : null,
          handler: () => {
            window.open('mailto:' + product.email);
          }
        },
        {
          text: `Call ( ${product.phone} )`,
          icon: mode !== 'ios' ? 'call' : null,
          handler: () => {
            window.open('tel:' + product.phone);
          }
        },
        {
          text: 'Cancel',
          role: 'cancel'
        }
      ]
    });

    await actionSheet.present();
  }
}
