// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { Module } from './Module';
import { Service } from './Service';
import { DummyMainItemPageService } from './Pages/DummyMain/Item/DummyMainItemPageService';
import { DummyMainItemPageStore } from './Pages/DummyMain/Item/DummyMainItemPageStore';

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

/**
 * Использовать сервис страницы сущности "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5DummyMainItemPageService(
  getter?: () => DummyMainItemPageService
) {
  const module = Module.get();

  if (getter) {
    module.serviceOfDummyMainItemPageGetter = getter;
  }

  return module.service;
}

/**
 * Использовать хранилище страницы сущности "DummyMain" слоя "Layer5".
 * @param getter Получатель.
 * @returns Хранилище.
 */
export function useLayer5DummyMainItemPageStore(
  getter?: () => DummyMainItemPageStore
) {
  const module = Module.get();

  if (getter) {
    module.storeOfDummyMainItemPageGetter = getter;
  }

  return module.storeOfDummyMainItemPage;
}
