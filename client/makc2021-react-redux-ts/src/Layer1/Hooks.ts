import { Module as Layer1Module } from 'src/Layer1/Module';
import { HttpService } from 'src/Layer1/Http/HttpService';
import { UrlService } from 'src/Layer1/Url/UrlService';

/**
 * Использовать сервис HTTP слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1HttpService(getter?: () => HttpService) {
  const module = Layer1Module.get();

  if (getter) {
    module.httpServiceGetter = getter;
  }

  return module.httpService;
}

/**
 * Использовать сервис URL слоя "Layer1".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer1UrlService(getter?: () => UrlService) {
  const module = Layer1Module.get();

  if (getter) {
    module.urlServiceGetter = getter;
  }

  return module.urlService;
}
