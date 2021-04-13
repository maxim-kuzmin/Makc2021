import { useLayer1HttpService, useLayer1UrlService } from './Layer1/Hooks';
import { HttpService } from './Layer1/Http/HttpService';
import { UrlService } from './Layer1/Url/UrlService';
import { Module as Layer1Module } from './Layer1/Module';
import { Module as Layer5Module } from './Layer5/Module';
import { Service as Layer5Service } from './Layer5/Service';
import { DummyMainItemPageService } from './Layer5/Pages/DummyMain/Item/DummyMainItemPageService';
import { DummyMainItemPageStore } from './Layer5/Pages/DummyMain/Item/DummyMainItemPageStore';

/**
 * Использовать модуль слоя "Layer1"
 */
export function useLayer1Module() {
  let httpService: HttpService;

  useLayer1HttpService(() => {
    if (!httpService) {
      httpService = new HttpService();
    }

    return httpService;
  });

  let urlService: UrlService;

  useLayer1UrlService(() => {
    if (!urlService) {
      urlService = new UrlService();
    }

    return urlService;
  });
}

/**
 * Использовать модуль слоя "Layer5".
 * @param apiUrl URL API.
 */
export function useLayer5Module(apiUrl: string) {
  const module = Layer5Module.get();

  let service: Layer5Service;

  module.serviceGetter = () => {
    if (!service) {
      service = new Layer5Service(apiUrl);
    }

    return service;
  };

  let serviceOfDummyMainItemPage: DummyMainItemPageService;

  module.serviceOfDummyMainItemPageGetter = () => {
    if (!serviceOfDummyMainItemPage) {
      serviceOfDummyMainItemPage = new DummyMainItemPageService(
        Layer1Module.get().httpService,
        module.service
      );
    }

    return serviceOfDummyMainItemPage;
  };

  let storeOfDummyMainItemPage: DummyMainItemPageStore;

  module.storeOfDummyMainItemPageGetter = () => {
    if (!storeOfDummyMainItemPage) {
      storeOfDummyMainItemPage = new DummyMainItemPageStore(
        module.serviceOfDummyMainItemPage
      );
    }

    return storeOfDummyMainItemPage;
  };
}
