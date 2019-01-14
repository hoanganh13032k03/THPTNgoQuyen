/// <reference path="../ckfinder/ckfinder.html" />
/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
    config.language = 'en';
    config.filebrowserBrowseUrl = "/Content/js/plugins/ckfinder/ckfinder.html"
    config.filebrowserImageBrowseUrl = "/Content/js/plugins/ckfinder/ckfinder.html?type=Images"
    config.filebrowserFlashBrowseUrl = "/Content/js/plugins/ckfinder/ckfinder.html?type=Flash"
    config.filebrowserUploadUrl = "/Content/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files"
    config.filebrowserImageUploadUrl = "/Content/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images"
    config.filebrowserFlashUploadUrl = "/Content/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash"
	// config.uiColor = '#AADC6E';
};
