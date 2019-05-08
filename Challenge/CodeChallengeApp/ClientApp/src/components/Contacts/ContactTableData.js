import React from 'react';
import ReactDOM from 'react-dom';
import { Icon } from 'semantic-ui-react';


class ContactTableData extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            contactData: null,
        };
    };

    render() {
        const { key, contact } = this.props;
        return (
            < tr key={key}>

                <td>{contact.name}</td>
                <td>{contact.email}</td>
                <td>{contact.phone}</td>
                <td>
                    <Icon name="edit" contact={contact} onClick={() => this.props.selectContact(contact)} />
                    <Icon name="delete" contact={contact} onClick={() => this.props.deleteSelectContact(contact)} />
                </td>
            </tr >
        );
    }
}
export default contactTableData;