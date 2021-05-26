// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { useTranslation } from 'react-i18next';
import { Configurator } from 'src/Configurator';

/**
 * Страница контактов.
 */
export function ContactsPage() {
  const { t } = useTranslation('Layer6/Pages/Contacts/ContactsPage');

  const resource = Configurator.Layer6.Pages.Contacts.getModule().createResource(
    Configurator.Layer1.getModule().createLocalizationService(t)
  );

  return (
    <>
      <Row>
        <Col>{resource.getAuthorFieldTitle()}</Col>
        <Col style={{ whiteSpace: 'nowrap' }}>
          {resource.getAuthorFieldValue()}
        </Col>
      </Row>
      <Row>
        <Col>{resource.getEmailFieldTitle()}</Col>
        <Col>maxim.kuzmin@inbox.ru</Col>
      </Row>
    </>
  );
}
