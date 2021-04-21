// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { useTranslation } from 'react-i18next';

/**
 * Страница контактов.
 */
export function ContactsPage() {
  const { t } = useTranslation();

  return (
    <>
      <Row>
        <Col>{t('Автор')}</Col>
        <Col>{t('Максим Кузьмин')}</Col>
      </Row>
      <Row>
        <Col>{t('E-mail')}</Col>
        <Col>maxim.kuzmin@inbox.ru</Col>
      </Row>
    </>
  );
}
