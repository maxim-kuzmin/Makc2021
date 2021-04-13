import { Module as Layer5Module } from 'src/Layer5/Module';
import { Service as Layer5Service } from 'src/Layer5/Service';
import { DummyMainItemPageService } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageService';
import { DummyMainItemPageStore } from 'src/Layer5/Pages/DummyMain/Item/DummyMainItemPageStore';

/**
 * Использовать сервис слоя "Layer5".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer5Service(getter?: () => Layer5Service) {
  const module = Layer5Module.get();

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
  const module = Layer5Module.get();

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
  const module = Layer5Module.get();

  if (getter) {
    module.storeOfDummyMainItemPageGetter = getter;
  }

  return module.storeOfDummyMainItemPage;
}
