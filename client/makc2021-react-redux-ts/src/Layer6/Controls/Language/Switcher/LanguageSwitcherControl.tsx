// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import FormControl from 'react-bootstrap/FormControl';
import { Configurator } from 'src/Configurator';
import { useLayer1LocalizationLanguage } from 'src/Layer1/Hooks';

/**
 * Элемент управления "Переключатель языка".
 */
export function LanguageSwitcherControl() {
  const language = useLayer1LocalizationLanguage(Configurator.Layer1);

  return (
    <FormControl
      as="select"
      value={language.current}
      onChange={(e) => language.change(e.target.value)}
      style={{ width: '7em' }}
    >
      <option value="en">English</option>
      <option value="ru">Русский</option>
    </FormControl>
  );
}
