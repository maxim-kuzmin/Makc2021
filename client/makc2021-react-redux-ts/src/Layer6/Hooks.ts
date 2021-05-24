// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module as Layer1Module } from 'src/Layer1/Module';
import { useLayer6ContactsPage } from './Pages/Contacts/ContactsPageHooks';
import { ContactsPageModule } from './Pages/Contacts/ContactsPageModule';
import { useLayer6DummyMainItemPage } from './Pages/DummyMain/Item/DummyMainItemPageHooks';
import { DummyMainItemPageModule } from './Pages/DummyMain/Item/DummyMainItemPageModule';
import { useLayer6DummyMainListPage } from './Pages/DummyMain/List/DummyMainListPageHooks';
import { DummyMainListPageModule } from './Pages/DummyMain/List/DummyMainListPageModule';
import { useLayer6DefaultTableControl } from './Controls/Tables/Default/DefaultTableControlHooks';
import { DefaultTableControlModule } from './Controls/Tables/Default/DefaultTableControlModule';
import { useLayer6QueryErrorControl } from './Controls/Errors/Query/QueryErrorControlHooks';
import { QueryErrorControlModule } from './Controls/Errors/Query/QueryErrorControlModule';
import { useLayer6TopMenuControl } from './Controls/Menus/Top/TopMenuControlHooks';
import { TopMenuControlModule } from './Controls/Menus/Top/TopMenuControlModule';

/**
 * Использовать слой "Layer6".
 */
export function useLayer6(
  moduleOfContactsPage: ContactsPageModule,
  moduleOfQueryErrorControl: QueryErrorControlModule,
  moduleOfTopMenuControl: TopMenuControlModule,
  moduleOfDefaultTableControl: DefaultTableControlModule,
  moduleOfDummyMainItemPage: DummyMainItemPageModule,
  moduleOfDummyMainListPage: DummyMainListPageModule,
  moduleOfLayer1: Layer1Module
) {
  useLayer6ContactsPage(moduleOfContactsPage, moduleOfLayer1);
  useLayer6DefaultTableControl(moduleOfDefaultTableControl, moduleOfLayer1);
  useLayer6DummyMainItemPage(moduleOfDummyMainItemPage, moduleOfLayer1);
  useLayer6DummyMainListPage(moduleOfDummyMainListPage, moduleOfLayer1);
  useLayer6QueryErrorControl(moduleOfQueryErrorControl, moduleOfLayer1);
  useLayer6TopMenuControl(moduleOfTopMenuControl, moduleOfLayer1);
}
