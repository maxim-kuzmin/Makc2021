// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import { useTranslation } from 'react-i18next';
import { QueryErrorControlProps } from './QueryErrorControlProps';

/**
 * Элемент управления "Ошибка запроса".
 */
export function QueryErrorControl({
  queryCode,
  messages
}: QueryErrorControlProps) {
  const { t } = useTranslation();

  return messages && messages.length > 0 ? (
    <>
      <h3>{t('Ошибки в запросе {{queryCode}}', { queryCode })}</h3>
      <ul>
        {messages.map((message) => (
          <li key={message}>{message}</li>
        ))}
      </ul>
    </>
  ) : null;
}
