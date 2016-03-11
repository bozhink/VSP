<?xml version="1.0"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns="http://www.w3.org/1999/xhtml">
  <xsl:param name="maxmin" select="'yes'" />
  <xsl:param name="pricestock" select="'price'" />
  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"
		doctype-public="-//W3C//DTD XHTML 1.0 Strict//EN "
		doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd" />
  <xsl:template match="/">
    <xsl:variable name="maxprice" select="max(products/product/price)" />
    <xsl:variable name="minprice" select="min(products/product/price)" />
    <xsl:variable name="maxstock" select="max(products/product/stock)" />
    <xsl:variable name="minstock" select="min(products/product/stock)" />
    <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
      <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <style type="text/css">
          body{font-family:verdana} .thColor{background-color:silver}
          .altColor{background-color:lightgreen} .count{text-align:center}
          .number{text-align:right}
        </style>
        <title>Catalog of Products</title>
      </head>
      <body>
        <h1>Catalog of Products</h1>
        <p>
          <xsl:value-of select="format-dateTime(current-dateTime(), '[Y]-[M,2]-[D,2] [H01]:[m01]:[s01]' )" />
        </p>
        <xsl:if test="$maxmin eq 'yes'">
          <p>
            Max price: <xsl:value-of select="concat($maxprice, ' (', products/product[price = $maxprice]/name, ')')" /><br />
            Min price: <xsl:value-of select="concat($minprice, ' (', products/product[price = $minprice]/name, ')')" /><br />
            Max stock: <xsl:value-of select="concat($maxstock, ' (', products/product[stock = $maxstock]/name, ')')" /><br />
            Min stock: <xsl:value-of select="concat($minstock, ' (', products/product[stock = $minstock]/name, ')')" />
          </p>
        </xsl:if>
        <table border="1" cellpadding="5" cellspacing="0">
          <tr class="thColor">
            <th>No</th>
            <th>Name</th>
            <th>Price</th>
            <th>Stock</th>
            <th>Country</th>
          </tr>
          <xsl:call-template name="tableRow" />
        </table>
      </body>
    </html>
  </xsl:template>

  <xsl:template name="tableRow">
    <xsl:variable name="a" select="if ($pricestock eq 'price') then 'ascending' else 'descending'" />
    <xsl:for-each select="products/product">
      <xsl:sort order="{$a}" select="*[name() = $pricestock]" data-type="number" />
      <tr>
        <xsl:if test="position() mod 2 = 0">
          <xsl:attribute name="class">altColor</xsl:attribute>
        </xsl:if>
        <td class="tdCount">
          <xsl:value-of select="position()" />
        </td>
        <td>
          <xsl:value-of select="name" />
        </td>
        <td class="tdNumber">
          <xsl:value-of select="price" />
        </td>
        <td class="tdNumber">
          <xsl:value-of select="stock" />
        </td>
        <td>
          <xsl:value-of select="country" />
        </td>
      </tr>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
