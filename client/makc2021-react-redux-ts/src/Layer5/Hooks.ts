// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module as Layer1Module } from 'src/Layer1/Module';
import { Module } from './Module';
import { Service } from './Service';
import { DummyMainItemPageModule } from './Pages/DummyMain/Item/DummyMainItemPageModule';
import { useLayer5DummyMainItemPage } from './Pages/DummyMain/Item/DummyMainItemPageHooks';
import { DummyMainListPageModule } from './Pages/DummyMain/List/DummyMainListPageModule';
import { useLayer5DummyMainListPage } from './Pages/DummyMain/List/DummyMainListPageHooks';

/**
 * Использовать слой "Layer5".
 * @param apiUrl URL API.
 */
export function useLayer5(
  module: Module,
  moduleOfDummyMainItemPage: DummyMainItemPageModule,
  moduleOfDummyMainListPage: DummyMainListPageModule,
  moduleOfLayer1: Layer1Module,
  apiUrl: string
) {
  let service: Service;

  useLayer5Service(module, () => {
    if (!service) {
      service = new Service(apiUrl);
    }

    return service;
  });

  useLayer5DummyMainItemPage(moduleOfDummyMainItemPage, module, moduleOfLayer1);
  useLayer5DummyMainListPage(moduleOfDummyMainListPage, module, moduleOfLayer1);
}

/**
 * Использовать сервис слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5Service(module: Module, getter?: () => Service) {
  if (getter) {
    module.serviceGetter = getter;
  }

  return module.service;
}
