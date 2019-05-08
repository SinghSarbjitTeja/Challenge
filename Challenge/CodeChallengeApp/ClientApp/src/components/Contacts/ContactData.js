import React from 'react';
import ReactDOM from 'react-dom';
import './Contacts.css';
import ContactTableData from './ContactTableData.js';

class contactData extends React.Component {
    constructor(props) {
        super(props);
    };

    render() {
        const contactData = this.props.contactData;
        return (
            <table>
                <thead>
                    <tr>

                        <th>Contact Name</th>
                        <th>Phone</th>
                        <th>Email</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody >
                    {
                        contactData.map(contact => (
                            <ContactTableData key={contact.Id} contact={contact} selectContact={this.props.selectContact} deleteSelectContact={this.props.deleteSelectContact} />

                        ))}
                </tbody>
            </table>
        );
    }
}
export default contactData;