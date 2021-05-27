// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import { Configurator } from 'src/Configurator';
import { useResource } from 'src/Layer1/Localization/LocalizationHooks';

/**
 * Страница контактов.
 */
export function ContactsPage() {
  const resource = useResource(
    Configurator.Layer6.Pages.Contacts.getModule().createResource,
    'Layer6/Pages/Contacts/ContactsPage'
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
