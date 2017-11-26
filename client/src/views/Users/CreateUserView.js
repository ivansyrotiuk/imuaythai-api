import React from "react";
import PropTypes from "prop-types";
import "react-datepicker/dist/react-datepicker.css";
import { Field, reduxForm } from "redux-form";
import Datetime from "react-datetime";
import "react-datetime/css/react-datetime.css";
import Page from "../../components/Page/Page";
import PageHeader from "../../components/Page/PageHeader";
import Icon from "../../components/Common/Icon";
import PageContent from "../../components/Page/PageContent";
import Row from "../../components/Layout/Row";
import Col from "../../components/Layout/Col";

const socialMediaInputStyleStyle = {
    zIndex: 0
};

const RenderDatePicker = props => {
    return <Datetime {...props.input} selected={props.input.value} dateFormat="DD-MM-YYYY" timeFormat="HH:mm" required />;
};

const CreateUserView = props => {
    const mappedGyms = props.gyms.map((gym, i) => (
        <option key={i} value={gym.id}>
            {gym.name}
        </option>
    ));
    const mappedCountries = props.countries.map((country, i) => (
        <option key={i} value={country.id}>
            {country.name}
        </option>
    ));
    const mappedRoles = props.roles.map((role, i) => (
        <option key={i} value={role.id}>
            {role.name}
        </option>
    ));

    const { handleSubmit, countryChange, pristine, reset, submitting } = props;

    return (
        <Page>
            <PageHeader>
                <Icon name="fa-user" /> Create user
            </PageHeader>
            <PageContent>
                <form onSubmit={handleSubmit}>
                    <Row>
                        <Col className="col-6">
                            <div className="form-group">
                                <label htmlFor="text-input">First name</label>
                                <Field name="firstname" component="input" type="text" className="form-control" placeholder="First Name" required />
                            </div>
                        </Col>
                        <Col className="col-6">
                            <div className="form-group">
                                <label htmlFor="text-input">Surname</label>
                                <Field name="surname" component="input" className="form-control" type="text" placeholder="Surname" required />
                            </div>
                        </Col>
                    </Row>
                    <Row>
                        <Col className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="text-input">Birthdate</label>
                                <Field name="birthdate" component={RenderDatePicker} type="input" />
                            </div>
                        </Col>
                        <Col className="col-md-6">
                            <div className="form-group">
                                <label htmlFor="text-input">Gender</label>
                                <Field name="gender" component="select" className="form-control" required>
                                    <option value="">Please select</option>
                                    <option value="male">Male</option>
                                    <option value="female">Female</option>
                                </Field>
                            </div>
                        </Col>
                    </Row>
                    <Row>
                        <Col className="col-md-6">
                            <Row>
                                <Col className="col-6">
                                    <div className="form-group">
                                        <label htmlFor="text-input">Email</label>
                                        <Field
                                            name="email"
                                            component="input"
                                            type="text"
                                            className="form-control"
                                            placeholder="Email"
                                            required
                                            pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$"
                                        />
                                    </div>
                                </Col>
                                <Col className="col-md-6">
                                    <div className="form-group">
                                        <label htmlFor="text-input">Phone</label>
                                        <Field name="phone" component="input" className="form-control" type="text" placeholder="Phone" />
                                    </div>
                                </Col>
                            </Row>
                            <Row>
                                <Col className="col">
                                    <div className="form-group">
                                        <label htmlFor="text-input">Password</label>
                                        <Field name="password" component="input" type="password" className="form-control" placeholder="Password" required />
                                    </div>
                                </Col>
                            </Row>
                        </Col>
                        <Col className="col-md-6">
                            <Row>
                                <Col className="col-md-6">
                                    <div className="form-group">
                                        <label htmlFor="text-input">Nationality</label>
                                        <Field name="nationality" component="input" className="form-control" type="input" placeholder="Nationality" />
                                    </div>
                                </Col>
                                <Col className="col-md-6">
                                    <div className="form-group">
                                        <label className="form-control-label" htmlFor="text-input">
                                            Country
                                        </label>
                                        <Field name="countryId" className="form-control" component="select" onChange={countryChange} required>
                                            <option value="">No country</option>
                                            {mappedCountries}
                                        </Field>
                                    </div>
                                </Col>
                            </Row>
                            <Row>
                                <Col className="col-md-6">
                                    <div className="form-group">
                                        <label className=" form-control-label" htmlFor="text-input">
                                            Gym
                                        </label>
                                        <Field name="institutionId" className="form-control" component="select" required>
                                            <option value="">No gym</option>
                                            {mappedGyms}
                                        </Field>
                                    </div>
                                </Col>
                                <Col className="col-md-6">
                                    <div className="form-group">
                                        <label htmlFor="text-input">Roles</label>
                                        <Field name="roleId" component="select" className="form-control" placeholder="Role" required>
                                            <option value="">No role</option>
                                            {mappedRoles}
                                        </Field>
                                    </div>
                                </Col>
                            </Row>
                        </Col>
                    </Row>
                    <Row>
                        <Col className="col-md-6">
                            <div className="form-group">
                                <div className="input-group">
                                    <span className="input-group-addon">
                                        <Icon name="fa-facebook" />
                                    </span>
                                    <Field
                                        name="facebook"
                                        component="input"
                                        type="text"
                                        className="form-control"
                                        placeholder="Facebook"
                                        style={socialMediaInputStyleStyle}
                                    />
                                </div>
                            </div>
                        </Col>
                        <Col className="col-md-6">
                            <div className="form-group">
                                <div className="input-group">
                                    <span className="input-group-addon">
                                        <Icon name="fa-instagram" />
                                    </span>
                                    <Field
                                        name="instagram"
                                        component="input"
                                        className="form-control"
                                        type="text"
                                        placeholder="Instagram"
                                        style={socialMediaInputStyleStyle}
                                    />
                                </div>
                            </div>
                        </Col>
                    </Row>

                    <Row>
                        <Col className="col-md-6">
                            <div className="form-group">
                                <div className="input-group">
                                    <span className="input-group-addon">
                                        <Icon name="fa-twitter" />
                                    </span>
                                    <Field
                                        name="twitter"
                                        component="input"
                                        className="form-control"
                                        type="input"
                                        placeholder="Twitter"
                                        style={socialMediaInputStyleStyle}
                                    />
                                </div>
                            </div>
                        </Col>
                        <Col className="col-md-6">
                            <div className="form-group">
                                <div className="input-group">
                                    <span className="input-group-addon">
                                        <Icon name="fa-vk" />
                                    </span>
                                    <Field
                                        name="vk"
                                        component="input"
                                        className="form-control"
                                        type="input"
                                        placeholder="Vk"
                                        style={socialMediaInputStyleStyle}
                                    />
                                </div>
                            </div>
                        </Col>
                    </Row>

                    <button type="submit" disabled={pristine || submitting} className="btn btn-primary pull-right">
                        {submitting && <Icon className="fa-spinner fa-pulse fa-1x fa-fw" />} Save
                    </button>
                </form>
            </PageContent>
        </Page>
    );
};

CreateUserView.propTypes = {
    gyms: PropTypes.array,
    countries: PropTypes.array,
    roles: PropTypes.array
};

CreateUserView.defaultProps = {
    gyms: [],
    countries: [],
    roles: []
};

export default reduxForm({ form: "CreateNewUserForm" })(CreateUserView);
