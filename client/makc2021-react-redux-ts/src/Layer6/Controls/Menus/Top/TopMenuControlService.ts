// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { CommonMenuData } from 'src/Layer6/Common/Menu/CommonMenuData';
import {
  CommonMenuItem,
  createCommonMenuItem
} from '../../../Common/Menu/CommonMenuItem';
import { TopMenuControlResource } from './TopMenuControlResource';

/**
 * Сервис элемента управления "Верхнее меню".
 */
export class TopMenuControlService {
  readonly data: CommonMenuData;

  // App

  readonly itemOfApp = createCommonMenuItem('App');

  readonly itemOfAppContactsPage = createCommonMenuItem('AppContactsPage');

  readonly itemOfAppDummyMainItemPage = createCommonMenuItem(
    'AppDummyMainItemPage'
  );

  readonly itemOfAppDummyMainListPage = createCommonMenuItem(
    'AppDummyMainListPage'
  );

  /**
   * Конструктор.
   */
  constructor() {
    this.compose(this.itemOfAppContactsPage, '/contacts', this.itemOfApp);

    this.compose(
      this.itemOfAppDummyMainItemPage,
      '/dummy-main/item',
      this.itemOfApp
    );
    this.compose(
      this.itemOfAppDummyMainListPage,
      '/dummy-main/list',
      this.itemOfApp
    );

    this.data = new CommonMenuData([this.itemOfApp]);
  }

  /**
   * Загрузить ресурс.
   * @param resource Ресурс.
   */
  loadResource(resource: TopMenuControlResource) {
    this.itemOfApp.text = resource.getAppIndexPageLinkTitle();
    this.itemOfAppContactsPage.text = resource.getAppContactsPageLinkTitle();
    this.itemOfAppDummyMainItemPage.text = resource.getAppDummyMainItemPageLinkTitle();
    this.itemOfAppDummyMainListPage.text = resource.getAppDummyMainListPageLinkTitle();
  }

  private compose(
    item: CommonMenuItem,
    path: string,
    parentItem?: CommonMenuItem
  ) {
    item.path = path;

    if (parentItem) {
      item.parent = parentItem;

      let children = parentItem.children;

      if (!children) {
        parentItem.children = children = [];
      }

      children.push(item);

      if (children.length === 1) {
        parentItem.path = item.path;
      }
    }
  }
}
