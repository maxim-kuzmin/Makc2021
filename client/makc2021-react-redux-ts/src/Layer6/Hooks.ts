// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useLayer6ContactsPage } from './Pages/Contacts/ContactsPageHooks';
import { useLayer6DummyMainItemPage } from './Pages/DummyMain/Item/DummyMainItemPageHooks';
import { useLayer6DummyMainListPage } from './Pages/DummyMain/List/DummyMainListPageHooks';
import { useLayer6DefaultTableControl } from './Controls/Tables/Default/DefaultTableControlHooks';
import { useLayer6QueryErrorControl } from './Controls/Errors/Query/QueryErrorControlHooks';
import { useLayer6TopMenuControl } from './Controls/Menus/Top/TopMenuControlHooks';

/**
 * Использовать слой "Layer6".
 */
export function useLayer6() {
  useLayer6ContactsPage();
  useLayer6DefaultTableControl();
  useLayer6DummyMainItemPage();
  useLayer6DummyMainListPage();
  useLayer6QueryErrorControl();
  useLayer6TopMenuControl();
}
