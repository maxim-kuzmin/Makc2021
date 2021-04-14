// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module } from './Module';
import { Service } from './Service';
import { useLayer5DummyMainItemPage } from './Pages/DummyMain/Item/DummyMainItemPageHooks';
import { useLayer5DummyMainListPage } from './Pages/DummyMain/List/DummyMainListPageHooks';

/**
 * Использовать слой "Layer5".
 * @param apiUrl URL API.
 */
export function useLayer5(apiUrl: string) {
  let service: Service;

  useLayer5Service(() => {
    if (!service) {
      service = new Service(apiUrl);
    }

    return service;
  });

  useLayer5DummyMainItemPage();
  useLayer5DummyMainListPage();
}

/**
 * Использовать сервис слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5Service(getter?: () => Service) {
  const module = Module.get();

  if (getter) {
    module.serviceGetter = getter;
  }

  return module.service;
}
