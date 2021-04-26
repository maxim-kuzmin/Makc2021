// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { Module as Layer1Module } from 'src/Layer1/Module';
import { LocalizationService } from 'src/Layer1/Localization/LocalizationService';
import { TopMenuControlModule } from './TopMenuControlModule';
import { TopMenuControlResource } from './TopMenuControlResource';

/**
 * Использовать элемент управления "Верхнее меню" слоя "Layer6".
 */
export function useLayer6TopMenuControl() {
  useLayer6TopMenuControlResource(
    (localizationService: LocalizationService) => {
      return new TopMenuControlResource(localizationService);
    }
  );
}

/**
 * Использовать ресурс элемента управления "Верхнее меню" слоя "Layer6".
 * @param getter Получатель.
 * @returns Сервис.
 */
export function useLayer6TopMenuControlResource(
  getter?: (localizationService: LocalizationService) => TopMenuControlResource
) {
  const { t } = useTranslation('Layer6/Controls/Menus/Top/TopMenuControl');

  const module = TopMenuControlModule.get();

  if (getter) {
    module.resourceGetter = getter;
  }

  return module.createResource(Layer1Module.get().createLocalizationService(t));
}
